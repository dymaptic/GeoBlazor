export function initialize(dotNetHelper, className) {
    // create a unique handler that captures the dotNetHelper and optional id
    const onMessage = async function (event) {
        if (event.data === null || event.data === undefined) {
            console.warn('TestFrame: Rejected null/undefined message data');
            return;
        }

        let messageObj = event.data;

        // if an id/target is provided, ignore messages not intended for this instance
        if (messageObj.class !== className) {
            return;
        }

        console.log('TestFrame: Processing valid message from', event.origin);

        try {
            await dotNetHelper.invokeMethodAsync('OnIframeMessage', messageObj);
        } catch (error) {
            console.error('TestFrame: Error invoking .NET method:', error);
        }
    };

    // ensure storage so handlers are retained/referencable
    window._testFrameHandlers = window._testFrameHandlers || [];
    window._testFrameHandlers.push({ className, handler: onMessage });

    window.addEventListener('message', onMessage);
    console.log('TestFrame: Message listener added for', className || '<no-id>');

    // return a dispose function so the caller can remove the listener when needed
    return function dispose() {
        window.removeEventListener('message', onMessage);
        const arr = window._testFrameHandlers || [];
        const idx = arr.findIndex(h => h.handler === onMessage);
        if (idx !== -1) arr.splice(idx, 1);
        console.log('TestFrame: Message listener removed for', className || '<no-id>');
    };
}

export function sendMessage(callbackName, messageData) {
    try {
        messageData.type = callbackName;
        window.parent.postMessage(messageData);
        console.log('TestFrame: Message sent from iframe');
        return true;
    } catch (error) {
        console.error('TestFrame: Failed to send message from iframe:', error);
        return false;
    }
}