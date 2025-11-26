import OAuthInfo from "@arcgis/core/identity/OAuthInfo";
import IdentityManager from "@arcgis/core/identity/IdentityManager";
import esriConfig from "@arcgis/core/config";
import {logUncaughtError} from "./geoBlazorCore";
export default class AuthenticationManager {
    private appId: string | undefined;
    private info: OAuthInfo | undefined;
    private dotNetRef: any;
    constructor(dotNetReference: any, apiKey: string | null, appId: string | null, portalUrl: string | null, 
                trustedServers: string[] | null, fontsUrl: string | null) {
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
        }
        if (apiKey !== null) {
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
        
        let interceptorName = 'authenticationManagerInterceptor';
        let currentInterceptor = esriConfig.log.interceptors
            .find(i => i.name === interceptorName);
        
        if (!currentInterceptor) {
            let newInterceptor = new Function('logUncaughtError',
                `return function ${interceptorName}(level, module, ...args) {
                    return logUncaughtError(level, module, 'global', ...args);
                }`);
            esriConfig.log.interceptors.push((newInterceptor(logUncaughtError) as __esri.LogInterceptor));
        }
    }

    setApiKey(apiKey: string | null): void {
        esriConfig.apiKey = apiKey;
    }

    async isLoggedIn(): Promise<boolean> {
            await IdentityManager.checkSignInStatus(this.info?.portalUrl + "/sharing");
        return true;
    }

    doLogin(): void {
        IdentityManager.getCredential(this.info?.portalUrl + "/sharing");
    }

    doLogout(): void {
        IdentityManager.destroyCredentials();
        window.location.reload();
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
        return credential.expires as any;
    }
    
    registerToken(token: string, expires: number): void {
        let server: string;
        if (this.info?.portalUrl !== undefined && this.info?.portalUrl !== null) {
            server = this.info.portalUrl + "/sharing/rest";
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