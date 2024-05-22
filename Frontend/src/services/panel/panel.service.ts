import { HttpClient } from "@angular/common/http";
import { BaseService } from "../base/base.service";
import { Observable } from "rxjs";
import { ICurrencyResponse, IUserDetails, IUserDetailsResponse } from "../../store/panel/panel.reducer";
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root'
})

export class PanelService extends BaseService{

    constructor(private http: HttpClient) {
        super();
    }

    getDetails(api: string): Observable<IUserDetailsResponse>{
        return this.http.get<IUserDetailsResponse>(this.url(api,"/user"));
    }

    getCurrency(api: string): Observable<ICurrencyResponse>{
        return this.http.get<ICurrencyResponse>(this.url(api,"/operations/currency"));
    }
}