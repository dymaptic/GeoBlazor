// authentication imports
import IdentityManager from "@arcgis/core/identity/IdentityManager";
import OAuthInfo from "@arcgis/core/identity/OAuthInfo";
import {arcGisObjectRefs} from "./arcGisJsInterop";

export default class OAuthAuthenticationWrapper {
    private appId: string;
    private info: OAuthInfo;

    constructor(dotNetReference, apiKey) {
        // We don't want to store the apiKey
        // so we just ignore this constructor.
        this.appId = "";
        this.info = new OAuthInfo({
            appId: "",
            flowType: "auto",
            popup: false,
        });
        
    }
    
    initialize(appId) {
        this.appId = appId;
        this.info = new OAuthInfo({
            appId: appId,
            flowType: "auto",
            popup: false,
        });
        IdentityManager.registerOAuthInfos([this.info]);
    }

    isLoggedIn(): Promise<boolean> {
        return new Promise((resolve) => {
            IdentityManager.checkSignInStatus(this.info.portalUrl + "/sharing")
                .then(() => resolve(true))
                .catch((e) => {
                    console.log(e);
                    resolve(false);
                });
        });
    }

    doLogin(): void {
        IdentityManager.getCredential(this.info.portalUrl + "/sharing");
    }

    getToken(): Promise<string> {
        return new Promise((resolve) => {
            IdentityManager.getCredential(this.info.portalUrl + "/sharing/rest")
                .then((cred) => resolve(cred.token))
                .catch(() => resolve(""));
        });

    }
}