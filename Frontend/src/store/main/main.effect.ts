import { Injectable } from "@angular/core";
import * as MainActions from "./main.actions";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { map, mergeMap, of } from "rxjs";
import { EnvService } from "../../services/env/env.service";

@Injectable()
export class MainEffects {
    constructor(private action$: Actions, private envService: EnvService ){
        //to jest zwykły konstruktor, to co przekażemy w nim to automatycznie zmapuje nam na property których będziemy mogli używać, nie trzeba przypisywać jak w C#
    }

    setEnviroment$ = createEffect(() => this.action$.pipe(
        ofType(MainActions.setEnviroment),
        mergeMap(action => of(action).pipe(
            mergeMap(() => this.envService.getEnviroment().pipe(
                map((url) => MainActions.setEnviromentSuccess({ url: url}))
            ))
        ))
    ))
}