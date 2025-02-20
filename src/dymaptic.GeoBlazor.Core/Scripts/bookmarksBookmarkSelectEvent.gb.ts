import {buildDotNetBookmarksBookmarkSelectEvent} from './bookmarksBookmarkSelectEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBookmarksBookmarkSelectEventGenerated(dotNetObject: any): Promise<any> {
    let jsBookmarksBookmarkSelectEvent: any = {}
    if (hasValue(dotNetObject.bookmark)) {
        let {buildJsBookmark} = await import('./bookmark');
        jsBookmarksBookmarkSelectEvent.bookmark = await buildJsBookmark(dotNetObject.bookmark) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBookmarksBookmarkSelectEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBookmarksBookmarkSelectEvent;

    let dnInstantiatedObject = await buildDotNetBookmarksBookmarkSelectEvent(jsBookmarksBookmarkSelectEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BookmarksBookmarkSelectEvent', e);
    }

    return jsBookmarksBookmarkSelectEvent;
}

export async function buildDotNetBookmarksBookmarkSelectEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBookmarksBookmarkSelectEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.bookmark)) {
        let {buildDotNetBookmark} = await import('./bookmark');
        dotNetBookmarksBookmarkSelectEvent.bookmark = await buildDotNetBookmark(jsObject.bookmark);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBookmarksBookmarkSelectEvent.id = k;
                break;
            }
        }
    }

    return dotNetBookmarksBookmarkSelectEvent;
}

