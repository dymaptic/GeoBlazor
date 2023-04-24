export async function getFromJsonStream(streamRef, offset) {
    const stream = await streamRef.stream();
    const reader = stream.getReader();
    let json = "";
    reader.read().then(function processText({done, value}) {
        if (done) {
            let graphics = JSON.parse(json);
            let elapsed = Date.now() - offset;
            console.log("JSON Stream loaded: " + elapsed);
            return;
        }
        json += new TextDecoder("utf-8").decode(value);
        return reader.read().then(processText);
    });
}

export async function getFromJson(graphics, offset) {
    let elapsed = Date.now() - offset;
    console.log("Graphics loaded from JSON: " + elapsed);
}