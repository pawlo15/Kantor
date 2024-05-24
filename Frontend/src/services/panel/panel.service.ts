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

    exchange(api: string, body: any) {
        console.log('jestem w serwisie')
        console.log(body)

        var mybody = {
            currency: body.value.currency.value,
            amount: body.value.amount,
            isSale: body.value.isSale
        }
        return this.http.post(this.url(api,"/operations/exchange"), mybody)
    }
}