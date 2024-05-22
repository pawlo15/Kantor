import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class BaseService {

    constructor() {}

    url(baseUrl: string, resource: string){
        return baseUrl + resource;
    }
}