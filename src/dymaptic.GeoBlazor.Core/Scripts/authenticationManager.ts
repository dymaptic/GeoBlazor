import OAuthInfo from "@arcgis/core/identity/OAuthInfo";
import IdentityManager from "@arcgis/core/identity/IdentityManager";
import esriConfig from "@arcgis/core/config";

export default class AuthenticationManager {
    private appId: string | undefined;
    private info: OAuthInfo | undefined;
    private dotNetRef: any;

    constructor(dotNetReference, apiKey, appId, portalUrl, trustedServers, fontsUrl) {
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

        if (fontsUrl !== null) {
            esriConfig.fontsUrl = fontsUrl;
        }

        this.dotNetRef = dotNetReference;
    }

    setApiKey(apiKey: string): void {
        esriConfig.apiKey = apiKey;
    }
    
    async isLoggedIn(): Promise<boolean> {
        await IdentityManager.checkSignInStatus(this.info?.portalUrl + "/sharing");
        return true;
    }

    doLogin(): void {
        IdentityManager.getCredential(this.info?.portalUrl + "/sharing");
    }

    async getToken(): Promise<string | null> {
        if (this.appId === undefined) {
            return esriConfig.apiKey as string;
        }
        let credential = await IdentityManager.getCredential(this.info?.portalUrl + "/sharing");
        return credential.token;
    }
    
    async getTokenExpires(): Promise<number | null> {
        if (this.appId === undefined) {
            return null;
        }
        let credential = await IdentityManager.getCredential(this.info?.portalUrl + "/sharing");
        return credential.expires;
    }
    
    registerToken(token: string, expires: number): void {
        let server: string;
        if (this.info?.portalUrl !== undefined && this.info?.portalUrl !== null) {
            server = this.info.portalUrl + "/portal/sharing/rest";
        } else {
            server = "https://www.arcgis.com/sharing/rest";
        }
        
        IdentityManager.registerToken({
            expires: expires,
            server: server,
            ssl: true,
            token: token
        });
    }
}