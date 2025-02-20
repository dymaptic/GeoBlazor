import {buildDotNetBookmarksBookmarkEditEvent} from './bookmarksBookmarkEditEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBookmarksBookmarkEditEventGenerated(dotNetObject: any): Promise<any> {
    let jsBookmarksBookmarkEditEvent: any = {}
    if (hasValue(dotNetObject.bookmark)) {
        let {buildJsBookmark} = await import('./bookmark');
        jsBookmarksBookmarkEditEvent.bookmark = await buildJsBookmark(dotNetObject.bookmark) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBookmarksBookmarkEditEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBookmarksBookmarkEditEvent;

    let dnInstantiatedObject = await buildDotNetBookmarksBookmarkEditEvent(jsBookmarksBookmarkEditEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BookmarksBookmarkEditEvent', e);
    }

    return jsBookmarksBookmarkEditEvent;
}

export async function buildDotNetBookmarksBookmarkEditEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBookmarksBookmarkEditEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.bookmark)) {
        let {buildDotNetBookmark} = await import('./bookmark');
        dotNetBookmarksBookmarkEditEvent.bookmark = await buildDotNetBookmark(jsObject.bookmark);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBookmarksBookmarkEditEvent.id = k;
                break;
            }
        }
    }

    return dotNetBookmarksBookmarkEditEvent;
}

