import { Router } from "@angular/router";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { IMainState, getApi } from "../main/main.reducer";
import { Store } from "@ngrx/store";
import * as AuthActions from "./auth.actions";
import { catchError, exhaustMap, map, of, withLatestFrom } from "rxjs";
import { getCredentials } from "./auth.reducer";
import { HttpErrorResponse } from "@angular/common/http";
import { AuthService } from "../../services/auth/auth.service";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthEffect {

    constructor(
        private action$: Actions,
        private service: AuthService,
        private router: Router,
        private store: Store<IMainState>
    ) { }

    login$ = createEffect(() => this.action$.pipe(
        ofType(AuthActions.login),
        withLatestFrom(
            this.store.select(getApi),
            this.store.select(getCredentials)
        ),
        exhaustMap(([,api, details]) => 
            this.service.login(api,details)
            .pipe(
                map((token) => {
                    return AuthActions.loginSuccess({ token: token});
                }),
                catchError((err: HttpErrorResponse) => {
                    console.log(err)
                    return of(AuthActions.loginFailed({ message: err.error.Message}))
                })
            ))
    ))
}