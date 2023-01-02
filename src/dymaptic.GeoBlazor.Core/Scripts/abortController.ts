export function createAbortControllerAndSignal() {
    const controller = new AbortController();
    const signal = controller.signal;
    return {
        // @ts-ignore
        controller: DotNet.createJSObjectReference(controller),
        // @ts-ignore
        signal: DotNet.createJSObjectReference(signal)
    }
}