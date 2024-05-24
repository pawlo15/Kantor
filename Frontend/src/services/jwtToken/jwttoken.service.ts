import { Injectable } from "@angular/core";
import * as jwt_decode from 'jwt-decode';

@Injectable({
    providedIn: 'root'
})

export class JWTTokenService {

    jwtToken: string | null;

    constructor(){
        this.jwtToken = null;
     }

    setToken(token: string) {
        if(token) {
            this.jwtToken = token;
        }
    }

    getToken() {
        if(this.jwtToken == null)
            this.jwtToken = sessionStorage.getItem("accessToken");
        return sessionStorage.getItem("accessToken");
    }

    decodeToken(){
        // if(this.jwtToken) {
        //     this.decodedToken = jwt_decode.default(this.jwtToken)
        // }
        
    }

    getExpiryTime() {
        // this.decodedToken();
        // return this.decodedToken ? this.decodedToken.exp : null
    }

    isTokenExpired(): boolean {
        const expiryTime : any = this.getExpiryTime();
        if(expiryTime){
            return ((1000*expiryTime)-(new Date()).getTime()) < 5000;
        } else {
            return false;
        }
    }
}