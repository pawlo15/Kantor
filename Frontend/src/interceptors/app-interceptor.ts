import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { JWTTokenService } from "../services/jwtToken/jwttoken.service";

@Injectable()
export class UniversalAppInterceptor implements HttpInterceptor {

    constructor(private JWTService: JWTTokenService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var modifiedReq = req.clone({
            headers: req.headers.set('Authorization', `Bearer ${this.JWTService.getToken()}`)
        });

        return next.handle(modifiedReq);
    }

}