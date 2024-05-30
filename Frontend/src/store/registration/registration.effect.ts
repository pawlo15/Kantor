import { Store } from "@ngrx/store";
import { RegistrationService } from "../../services/registration/registration.service";
import { getRegistrationDetails } from "./registration.reducer";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import * as RegistrationActions from "./registration.actions";
import * as AuthActions from "../auth/auth.actions";
import { catchError, exhaustMap, map, of, switchMap, withLatestFrom } from "rxjs";
import { IMainState, getApi } from "../main/main.reducer";
import { HttpErrorResponse } from "@angular/common/http";

@Injectable()
export class RegistrationEffect { 

    constructor(
        private action$: Actions,
        private service: RegistrationService,
        private store: Store<IMainState>
    ) { }

    registration$ = createEffect(() => this.action$.pipe(
        ofType(RegistrationActions.registration),
        withLatestFrom(
            this.store.select(getApi),
            this.store.select(getRegistrationDetails)
        ),
        exhaustMap(([, api, details]) =>
            this.service.sendRequest(api, details)
        .pipe(
            map(() => {
                return RegistrationActions.registrationSuccess();
            }),
            catchError((err: HttpErrorResponse) => {
                console.log(err)
                return of()
            })
        ))
    ))

    registrationSuccess$ = createEffect(() => this.action$.pipe(
        ofType(RegistrationActions.registrationSuccess),
        switchMap(() => [
            AuthActions.navigateToLoginPage()
        ])
    ))
}