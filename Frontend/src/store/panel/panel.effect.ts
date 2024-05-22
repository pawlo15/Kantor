import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import * as PanelActions from './panel.actions';
import { catchError, exhaustMap, map, of, pipe, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { IMainState, getApi } from "../main/main.reducer";
import { PanelService } from "../../services/panel/panel.service";
import { HttpErrorResponse } from "@angular/common/http";

@Injectable()
export class PanelEffects {
    constructor(private action$: Actions, 
        private store: Store<IMainState>,
        private service: PanelService){
        //to jest zwykły konstruktor, to co przekażemy w nim to automatycznie zmapuje nam na property których będziemy mogli używać, nie trzeba przypisywać jak w C#
    }

    getUserDetails$ = createEffect(() => this.action$.pipe(
        ofType(PanelActions.GetUserDetails),
        withLatestFrom(
            this.store.select(getApi)
        ),
        exhaustMap(([,api]) =>
            this.service.getDetails(api)
        ),
        pipe(
            map((data) =>{
                return PanelActions.GetUserDetailsSuccess({ user: data});
            }),
            catchError((err: HttpErrorResponse) => {
                return of()
            })
        )
    ))

    getCurrencies$ = createEffect(() => this.action$.pipe(
        ofType(PanelActions.GetCurrencies),
        withLatestFrom(
            this.store.select(getApi)
        ),
        exhaustMap(([,api]) =>
            this.service.getCurrency(api)
        ),
        pipe(
            map((data) => {
                return PanelActions.GetCurrenciesSuccess({ data: data });
            }),
            catchError((err: HttpErrorResponse) => {
                return of()
            })
        )
    ))
}