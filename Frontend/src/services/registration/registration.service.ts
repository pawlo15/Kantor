import { HttpClient } from "@angular/common/http";
import { BaseService } from "../base/base.service";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class RegistrationService extends BaseService{

    constructor(private http: HttpClient) {
        super();
    }

    sendRequest(api: string, details: any): Observable<any>{
        var body = {
            'login': details.controls.login.value,
            'password': details.controls.password.value,
            'email': details.controls.email.value,
            'name': details.controls.name.value
        };

        console.log(body);

        return this.http.post(this.url(api,'/auth/register'), body)
    }
}