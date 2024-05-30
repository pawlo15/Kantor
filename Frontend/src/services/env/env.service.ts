import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { IMainState } from "../../store/main/main.reducer";
import * as config from '../../assets/appsettings.json';

@Injectable({
    providedIn: 'root'
})
export class EnvService{
    constructor(private httpClient: HttpClient){

    }

    getEnviroment(): Observable<IMainState> {
        return of(config as IMainState);
    }
}