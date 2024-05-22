import { createAction, props } from "@ngrx/store";
import { IMainState } from "./main.reducer";

export const setEnviroment = createAction("[Main] Set Enviroment");
export const setEnviromentSuccess = createAction("[Main] Set Enviroment Success", props<{ url: IMainState }>());

export const setIsLoged = createAction("[Main] Set Is Logged");

export const clear = createAction("[Main] Clear");
export const empty = createAction("[Main] Empty Action");