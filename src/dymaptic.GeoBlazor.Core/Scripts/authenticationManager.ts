import OAuthInfo from "@arcgis/core/identity/OAuthInfo";
import IdentityManager from "@arcgis/core/identity/IdentityManager";
import esriConfig from "@arcgis/core/config";

export default class AuthenticationManager {
    private appId: string | undefined;
    private info: OAuthInfo | undefined;
    private dotNetRef: any;

    constructor(dotNetReference, apiKey, appId, portalUrl, trustedServers) {
        if (appId !== null) {
            this.appId = appId;
            this.info = new OAuthInfo({
                appId: appId,
                flowType: "auto",
                popup: false
            });
            if (portalUrl !== undefined && portalUrl !== null) {
                this.info.portalUrl = portalUrl;
            }
            IdentityManager.registerOAuthInfos([this.info]);
        } else if (apiKey !== null) {
            esriConfig.apiKey = apiKey;
        }
        if (portalUrl !== undefined && portalUrl !== null) {
            esriConfig.portalUrl = portalUrl;
        }
        
        if (trustedServers !== null) {
            esriConfig.request.trustedServers = esriConfig.request.trustedServers !== undefined ? esriConfig.request.trustedServers.concat(trustedServers) : trustedServers;
        }

        this.dotNetRef = dotNetReference;
    }

    async isLoggedIn(): Promise<boolean> {
        try {
            await IdentityManager.checkSignInStatus(this.info?.portalUrl + "/sharing");
            return true;
        } catch (e) {
            console.log(e);
            return false;
        }
    }

    doLogin(): void {
        IdentityManager.getCredential(this.info?.portalUrl + "/sharing");
    }

    async getToken(): Promise<string | null> {
        if (this.appId === undefined) {
            return esriConfig.apiKey;
        }
        try {
            let credential = await IdentityManager.getCredential(this.info?.portalUrl + "/sharing");
            return credential.token;
        } catch (e) {
            console.log(e);
            await this.dotNetRef.invokeMethodAsync("LoginFailed", e);
            return null;
        }

    }
}