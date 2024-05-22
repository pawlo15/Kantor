import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IMainState } from "../../store/main/main.reducer";

@Injectable({
    providedIn: 'root'
})
export class EnvService{
    constructor(private httpClient: HttpClient){

    }

    getEnviroment(): Observable<IMainState> {
        return this.httpClient.get<IMainState>("assets/appsettings.json") as Observable<IMainState>;
    }
}