import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import * as PanelActions from './panel.actions';
import { catchError, exhaustMap, map, of, pipe, switchMap, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { IMainState, getApi } from "../main/main.reducer";
import { PanelService } from "../../services/panel/panel.service";
import { HttpErrorResponse } from "@angular/common/http";
import { getAddMoneyRequest, getExchange } from "./panel.reducer";

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

    exchangeCurrency$ = createEffect(() => this.action$.pipe(
        ofType(PanelActions.ExchangeCurrency),
        withLatestFrom(
            this.store.select(getApi),
            this.store.select(getExchange)
        ),
        exhaustMap(([,api,body]) => 
            this.service.exchange(api,body)
        ),
        pipe(
            map(() => {
                return PanelActions.ExchangeCurrencySuccess();
            })
        )
    ))

    exchangeCurrencySuccess$ = createEffect(() => this.action$.pipe(
        ofType(PanelActions.ExchangeCurrencySuccess),
        switchMap(() => [
            PanelActions.GetUserDetails()
        ])
    ))

    addMoney$ = createEffect(() => this.action$.pipe(
        ofType(PanelActions.AddMoney),
        withLatestFrom(
            this.store.select(getApi),
            this.store.select(getAddMoneyRequest)
        ),
        exhaustMap(([,api, body]) =>
            this.service.addMoney(api, body)
        ),
        pipe(
            map(() => {
                return PanelActions.AddMoneySuccess();
            })
        ))
    )

    addMoneySuccess$ = createEffect(() => this.action$.pipe(
        ofType(PanelActions.AddMoneySuccess),
        switchMap(() => [
            PanelActions.GetUserDetails()
        ])
    ))
}