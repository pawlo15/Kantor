import { Injectable } from "@angular/core";
import { BaseService } from "../base/base.service";
import { HttpClient } from "@angular/common/http";
import { JWTTokenService } from "../jwtToken/jwttoken.service";
import { Observable } from "rxjs";
import { IToken } from "../../store/auth/auth.reducer";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

@Injectable({
    providedIn: 'root'
})

export class AuthService extends BaseService{

    constructor(private http: HttpClient, private jwt: JWTTokenService) {
        super();
    }

    login(api: string, credentials: any): Observable<IToken> {
        var body = {
            'login': credentials.controls.login.value,
            'password': credentials.controls.password.value
        }
        console.log('/auth/login')
        return this.http.post<IToken>(this.url(api,'/auth/login'), body);
    }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot){
        if(this.getJwtToken() && !this.jwt.isTokenExpired()){
            return true;
        }
        return false;
    }

    getJwtToken(){
        var token = sessionStorage.getItem("accessToken");
        if(token){
            return true;
        }
        return false;
    }

    logout(){
        sessionStorage.removeItem("accessToken");
        sessionStorage.removeItem("refreshToken");
    }
}