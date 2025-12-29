const { chromium } = require('playwright');
const { execSync } = require('child_process');
const path = require('path');
const fs = require('fs');

// Load .env file if it exists
const envPath = path.join(__dirname, '.env');
if (fs.existsSync(envPath)) {
    const envContent = fs.readFileSync(envPath, 'utf8');
    envContent.split('\n').forEach(line => {
        line = line.trim();
        if (line && !line.startsWith('#')) {
            const [key, ...valueParts] = line.split('=');
            const value = valueParts.join('=');
            if (key && !process.env[key]) {
                process.env[key] = value;
            }
        }
    });
}

const args = process.argv.slice(2);
for (const arg of args) {
    if (arg.indexOf('=') > 0 && arg.indexOf('=') < arg.length - 1) {
        let split = arg.split('=');
        let key = split[0].toUpperCase();
        let value = split[1];
        process.env[key] = value;
    } else {
        switch (arg.toUpperCase().replace('-', '').replace('_', '')) {
            case 'COREONLY':
                process.env.CORE_ONLY = true;
                break;
            case 'PROONLY':
                process.env.PRO_ONLY = true;
                break;
            case 'HEADLESS':
                process.env.HEADLESS = true;
                break;
        }
    }
}

// __dirname = GeoBlazor.Pro/GeoBlazor/test/Playwright
const coreDockerPath = path.resolve(__dirname, '..', '..', 'Dockerfile');
const proDockerPath = path.resolve(__dirname, '..', '..', '..', 'Dockerfile');

// if we are in GeoBlazor Core only, the pro file will not exist
const proExists = fs.existsSync(proDockerPath);

// Configuration
const CONFIG = {
    testAppUrl: process.env.TEST_APP_URL || 'https://localhost:8443',
    testTimeout: parseInt(process.env.TEST_TIMEOUT) || 30 * 60 * 1000, // 30 minutes default
    idleTimeout: parseInt(process.env.TEST_TIMEOUT) || 60 * 1000, // 1 minute default
    renderMode: process.env.RENDER_MODE || 'WebAssembly',
    coreOnly: process.env.CORE_ONLY || !proExists,
    proOnly: proExists && process.env.PRO_ONLY?.toLowerCase() === 'true',
    testFilter: process.env.TEST_FILTER || '',
    headless: process.env.HEADLESS?.toLowerCase() !== 'false',
};

// Log configuration at startup
console.log('Configuration:');
console.log(`  Test App URL: ${CONFIG.testAppUrl}`);
console.log(`  Test Filter: ${CONFIG.testFilter || '(none)'}`);
console.log(`  Render Mode: ${CONFIG.renderMode}`);
console.log(`  Core Only: ${CONFIG.coreOnly}`);
console.log(`  Pro Only: ${CONFIG.proOnly}`);
console.log(`  Headless: ${CONFIG.headless}`);
console.log('');

// Test result tracking
let testResults = {
    passed: 0,
    failed: 0,
    total: 0,
    failedTests: [],
    startTime: null,
    endTime: null,
    hasResultsSummary: false,  // Set when we see the final results in console
    allPassed: false,          // Set when all tests pass (no failures)
    retryPending: false,       // Set when we detect a retry is about to happen
    maxRetriesExceeded: false, // Set when 5 retries have been exceeded
    attemptNumber: 1           // Current attempt number (1-based)
};

// Reset test tracking for a new attempt (called on page reload)
function resetForNewAttempt() {
    testResults.passed = 0;
    testResults.failed = 0;
    testResults.total = 0;
    testResults.failedTests = [];
    testResults.hasResultsSummary = false;
    testResults.allPassed = false;
    testResults.retryPending = false;
    testResults.attemptNumber++;
    console.log(`\n  [RETRY] Starting attempt ${testResults.attemptNumber}...\n`);
}

async function waitForService(url, name, maxAttempts = 60, intervalMs = 2000) {
    console.log(`Waiting for ${name} at ${url}...`);

    for (let attempt = 1; attempt <= maxAttempts; attempt++) {
        try {
            // Don't follow redirects - just check if service responds
            const response = await fetch(url, { redirect: 'manual' });
            // Accept 2xx, 3xx (redirects) as "ready"
            if (response.status < 400) {
                console.log(`${name} is ready! (status: ${response.status})`);
                return true;
            }
        } catch (error) {
            // Service not ready yet
        }

        if (attempt % 10 === 0) {
            console.log(`Still waiting for ${name}... (attempt ${attempt}/${maxAttempts})`);
        }

        await new Promise(resolve => setTimeout(resolve, intervalMs));
    }

    throw new Error(`${name} did not become ready within ${maxAttempts * intervalMs / 1000} seconds`);
}

async function startDockerContainer() {
    console.log('Starting Docker container...');

    const composeFile = path.join(__dirname, 
        proExists && !CONFIG.coreOnly ? 'docker-compose-pro.yml' : 'docker-compose-core.yml');

    try {
        // Build and start container
        execSync(`docker compose -f "${composeFile}" up -d --build`, {
            stdio: 'inherit',
            cwd: __dirname
        });

        console.log('Docker container started. Waiting for services...');

        // Wait for test app HTTPS endpoint (using localhost since we're outside the container)
        // Note: Node's fetch will reject self-signed certs, so we check HTTP which is also available
        await waitForService('http://localhost:8080', 'Test Application (HTTP)');

    } catch (error) {
        console.error('Failed to start Docker container:', error.message);
        throw error;
    }
}

async function stopDockerContainer() {
    console.log('Stopping Docker container...');

    const composeFile = path.join(__dirname,
        proExists && !CONFIG.coreOnly ? 'docker-compose-pro.yml' : 'docker-compose-core.yml');

    try {
        execSync(`docker compose -f "${composeFile}" down`, {
            stdio: 'inherit',
            cwd: __dirname
        });
    } catch (error) {
        console.error('Failed to stop Docker container:', error.message);
    }
}

async function runTests() {
    let browser = null;
    let exitCode = 0;

    testResults.startTime = new Date();

    try {
        await startDockerContainer();

        console.log('\nLaunching local Chrome with GPU support...');

        // Chrome args for GPU/WebGL support
        const chromeArgs = [
            '--no-sandbox',
            '--disable-setuid-sandbox',
            '--ignore-certificate-errors',
            '--ignore-gpu-blocklist',
            '--enable-webgl',
            '--enable-webgl2-compute-context',
            '--use-angle=default',
            '--enable-gpu-rasterization',
            '--enable-features=Vulkan',
            '--enable-unsafe-webgpu',
        ];

        browser = await chromium.launch({
            headless: CONFIG.headless,
            args: chromeArgs,
        });

        console.log('Local Chrome launched!');

        // Get the default context or create a new one
        const context = browser.contexts()[0] || await browser.newContext();
        const page = await context.newPage();
        
        let logTimestamp;

        // Set up console message logging
        page.on('console', msg => {
            const type = msg.type();
            const text = msg.text();
            logTimestamp = Date.now();

            // Check for retry-related messages FIRST
            // Detect when the test runner is about to reload for a retry
            if (text.includes('Test Run Failed or Errors Encountered, will reload and make an attempt to continue')) {
                testResults.retryPending = true;
                console.log(`  [RETRY PENDING] Test run failed, retry will be attempted...`);
            }

            // Detect when max retries have been exceeded
            if (text.includes('Surpassed 5 reload attempts, exiting')) {
                testResults.maxRetriesExceeded = true;
                console.log(`  [MAX RETRIES] Exceeded 5 retry attempts, tests will stop.`);
            }

            // Check for the final results summary
            // This text appears in the full results output
            if (text.includes('GeoBlazor Unit Test Results')) {
                // This indicates the final summary has been generated
                testResults.hasResultsSummary = true;
                console.log(`  [RESULTS SUMMARY DETECTED] (Attempt ${testResults.attemptNumber})`);

                // Check if all tests passed (Failed: 0)
                if (text.includes('Failed: 0') || text.match(/Failed:\s*0/)) {
                    testResults.allPassed = true;
                    console.log(`  [ALL PASSED] All tests passed on attempt ${testResults.attemptNumber}!`);
                }
            }

            // Parse test results from console output
            // The test logger outputs "### TestName - Passed" or "### TestName - Failed"
            if (text.includes(' - Passed')) {
                testResults.passed++;
                testResults.total++;
                console.log(`  [PASS] ${text}`);
            } else if (text.includes(' - Failed')) {
                testResults.failed++;
                testResults.total++;
                testResults.failedTests.push(text);
                console.log(`  [FAIL] ${text}`);
            } else if (type === 'error') {
                console.error(`  [ERROR] ${text}`);
            } else if (text.includes('Running test')) {
                console.log(`  ${text}`);
            } else if (text.includes('Passed:') && text.includes('Failed:')) {
                // Summary line like "Passed: 5\nFailed: 0"
                console.log(`  [SUMMARY] ${text}`);
            }
        });

        // Set up error handling
        page.on('pageerror', error => {
            console.error(`Page error: ${error.message}`);
        });

        // Handle page navigation/reload events (for retry detection)
        // When the test runner reloads the page for a retry, we need to reset tracking
        page.on('framenavigated', frame => {
            // Only handle main frame navigations
            if (frame === page.mainFrame()) {
                // Only reset if we were expecting a retry (retryPending was set)
                if (testResults.retryPending) {
                    resetForNewAttempt();
                }
            }
        });

        // Build the test URL with parameters
        // Use Docker network hostname since browser is inside the container
        let testUrl = CONFIG.testAppUrl;
        const params = new URLSearchParams();

        if (CONFIG.renderMode) {
            params.set('renderMode', CONFIG.renderMode);
        }
        if (CONFIG.proOnly) {
            params.set('proOnly', 'true');
        }
        if (CONFIG.testFilter) {
            params.set('testFilter', CONFIG.testFilter);
        }
        // Auto-run tests
        params.set('RunOnStart', 'true');

        if (params.toString()) {
            testUrl += `?${params.toString()}`;
        }

        console.log(`\nNavigating to ${testUrl}...`);
        console.log(`Test timeout: ${CONFIG.testTimeout / 1000 / 60} minutes\n`);

        // Navigate to the test page
        await page.goto(testUrl, {
            waitUntil: 'networkidle',
            timeout: 60000
        });

        console.log('Page loaded. Waiting for tests to complete...\n');

        // Wait for tests to complete
        // The test runner will either:
        // 1. Show completion status in the UI
        // 2. Call the /exit endpoint which stops the application

        const completionPromise = new Promise(async (resolve, reject) => {
            const timeout = setTimeout(() => {
                reject(new Error(`Tests did not complete within ${CONFIG.testTimeout / 1000 / 60} minutes`));
            }, CONFIG.testTimeout);

            try {
                // Poll for test completion
                let lastStatusLog = '';
                while (true) {
                    await page.waitForTimeout(5000);

                    // Check if tests are complete by looking for completion indicators
                    const status = await page.evaluate(() => {
                        const result = {
                            hasRunning: false,
                            hasComplete: false,
                            totalPassed: 0,
                            totalFailed: 0,
                            testClassCount: 0,
                            hasResultsSummary: false
                        };

                        // Check all spans for status indicators
                        const allSpans = document.querySelectorAll('span');
                        for (const span of allSpans) {
                            const text = span.textContent?.trim();
                            if (text === 'Running...') {
                                result.hasRunning = true;
                            }
                            // Look for any span with "Complete" text (regardless of style)
                            if (text === 'Complete') {
                                result.hasComplete = true;
                            }
                        }

                        // Count test classes and sum up results
                        // Each test class section has "Passed: X" and "Failed: Y"
                        const bodyText = document.body.innerText || '';

                        // Check for the final results summary header "# GeoBlazor Unit Test Results"
                        if (bodyText.includes('GeoBlazor Unit Test Results')) {
                            result.hasResultsSummary = true;
                        }

                        // Count how many test class sections we have (look for pattern like "## ClassName")
                        const classMatches = bodyText.match(/## \w+Tests/g);
                        result.testClassCount = classMatches ? classMatches.length : 0;

                        // Sum up all Passed/Failed counts
                        const passMatches = [...bodyText.matchAll(/Passed:\s*(\d+)/g)];
                        const failMatches = [...bodyText.matchAll(/Failed:\s*(\d+)/g)];

                        for (const match of passMatches) {
                            result.totalPassed += parseInt(match[1]);
                        }
                        for (const match of failMatches) {
                            result.totalFailed += parseInt(match[1]);
                        }

                        return result;
                    });

                    // Log status periodically for debugging
                    const statusLog = `Attempt: ${testResults.attemptNumber}, Running: ${status.hasRunning}, Summary: ${testResults.hasResultsSummary}, RetryPending: ${testResults.retryPending}, Passed: ${testResults.passed}, Failed: ${testResults.failed}`;
                    if (statusLog !== lastStatusLog) {
                        console.log(`  [Status] ${statusLog}`);
                        lastStatusLog = statusLog;
                    }

                    // Tests are truly complete when:
                    // 1. No tests are running AND
                    // 2. We have the results summary from console AND
                    // 3. Either:
                    //    a. All tests passed (no retry needed), OR
                    //    b. Max retries exceeded (5 attempts), OR
                    //    c. No retry pending (failed but not retrying, e.g., filter applied)
                    //
                    // Note: The test runner sets retryPending=true when it will reload.
                    // After reload, resetForNewAttempt() clears retryPending.
                    // If we have a summary but retryPending is true, wait for the reload.

                    const isComplete = !status.hasRunning &&
                                       testResults.hasResultsSummary &&
                                       !testResults.retryPending &&
                                       (testResults.allPassed || testResults.maxRetriesExceeded || testResults.failed === 0);

                    if (isComplete) {
                        if (testResults.allPassed) {
                            console.log(`  [Status] All tests passed on attempt ${testResults.attemptNumber}!`);
                        } else if (testResults.maxRetriesExceeded) {
                            console.log(`  [Status] Tests completed after exceeding max retries (${testResults.attemptNumber} attempts)`);
                        } else {
                            console.log(`  [Status] All tests complete on attempt ${testResults.attemptNumber}!`);
                        }
                        clearTimeout(timeout);
                        resolve();
                        break;
                    }

                    // Also check if the page has navigated away or app has stopped
                    try {
                        await page.evaluate(() => document.body);
                    } catch (e) {
                        // Page might have closed, consider tests complete
                        clearTimeout(timeout);
                        resolve();
                        break;
                    }

                    if (Date.now() - logTimestamp > CONFIG.idleTimeout) {
                        throw new Error(`Aborting: No new messages within the past ${CONFIG.idleTimeout / 1000} seconds`);
                    }
                }
            } catch (error) {
                clearTimeout(timeout);
                reject(error);
            }
        });

        await completionPromise;

        // Try to extract final test results from the page
        try {
            const pageResults = await page.evaluate(() => {
                const results = {
                    passed: 0,
                    failed: 0,
                    failedTests: []
                };

                // Parse passed/failed counts from the page text
                // Format: "Passed: X" and "Failed: X"
                const bodyText = document.body.innerText || '';

                // Sum up all Passed/Failed counts from all test classes
                const passMatches = bodyText.matchAll(/Passed:\s*(\d+)/g);
                const failMatches = bodyText.matchAll(/Failed:\s*(\d+)/g);

                for (const match of passMatches) {
                    results.passed += parseInt(match[1]);
                }
                for (const match of failMatches) {
                    results.failed += parseInt(match[1]);
                }

                // Look for failed test details in the test result paragraphs
                // Failed tests have red-colored error messages
                const errorParagraphs = document.querySelectorAll('p[style*="color: red"]');
                errorParagraphs.forEach(el => {
                    const text = el.textContent?.trim();
                    if (text && !text.startsWith('Failed:')) {
                        results.failedTests.push(text.substring(0, 200)); // Truncate long messages
                    }
                });

                return results;
            });

            // Update results if we got them from the page
            if (pageResults.passed > 0 || pageResults.failed > 0) {
                testResults.passed = pageResults.passed;
                testResults.failed = pageResults.failed;
                testResults.total = pageResults.passed + pageResults.failed;
                if (pageResults.failedTests.length > 0) {
                    testResults.failedTests = pageResults.failedTests;
                }
            }
        } catch (e) {
            // Page might have closed
        }

        testResults.endTime = new Date();
        exitCode = testResults.failed > 0 ? 1 : 0;

    } catch (error) {
        console.error('\nTest run failed:', error.message);
        testResults.endTime = new Date();
        exitCode = 1;
    } finally {
        // Close browser connection
        if (browser) {
            try {
                await browser.close();
            } catch (e) {
                // Browser might already be closed
            }
        }

        await stopDockerContainer();
    }

    // Print summary
    printSummary();

    return exitCode;
}

function printSummary() {
    const duration = testResults.endTime && testResults.startTime
        ? ((testResults.endTime - testResults.startTime) / 1000).toFixed(1)
        : 'unknown';

    console.log('\n' + '='.repeat(60));
    console.log('TEST SUMMARY');
    console.log('='.repeat(60));
    console.log(`Total tests: ${testResults.total}`);
    console.log(`Passed: ${testResults.passed}`);
    console.log(`Failed: ${testResults.failed}`);
    console.log(`Attempts: ${testResults.attemptNumber}`);
    console.log(`Duration: ${duration} seconds`);

    if (testResults.failedTests.length > 0) {
        console.log('\nFailed tests:');
        testResults.failedTests.forEach(test => {
            console.log(`  - ${test}`);
        });
    }

    console.log('='.repeat(60));
    if (testResults.failed === 0 && testResults.passed === 0) {
        console.log(`NO TESTS RAN SUCCESSFULLY`);
    } else if (process.exitCode !== 1 && testResults.failed === 0) {
        if (testResults.attemptNumber > 1) {
            console.log(`ALL TESTS PASSED! (after ${testResults.attemptNumber} attempts)`);
        } else {
            console.log('ALL TESTS PASSED!');
        }
    } else {
        if (testResults.maxRetriesExceeded) {
            console.log('SOME TESTS FAILED (max retries exceeded)');
        } else {
            console.log('SOME TESTS FAILED');
        }
    }
    console.log('='.repeat(60) + '\n');
}

// Main execution
runTests()
    .then(exitCode => {
        process.exit(exitCode);
    })
    .catch(error => {
        console.error('Unexpected error:', error);
        process.exit(1);
    });