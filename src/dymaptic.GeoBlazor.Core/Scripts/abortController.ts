export function createAbortControllerAndSignal() {
    const controller = new AbortController();
    const signal = controller.signal;
    return {
        // @ts-ignore
        abortControllerRef: DotNet.createJSObjectReference(controller),
        // @ts-ignore
        abortSignalRef: DotNet.createJSObjectReference(signal)
    }
}