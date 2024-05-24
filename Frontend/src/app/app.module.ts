import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { AuthComponent } from "./auth/auth.component";
import { PanelComponent } from "./panel/panel.component";
import { AppRoutingModule } from "./app.routes";
import { Store, StoreModule } from "@ngrx/store";
import { appReducer } from "../store/app.state";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { IMainState } from "../store/main/main.reducer";
import { setEnviroment } from "../store/main/main.actions";
import { UniversalAppInterceptor } from "../interceptors/app-interceptor";
import { EffectsModule } from "@ngrx/effects";
import { rootEffect } from "../store/effects";
import { StoreDevtoolsModule } from "@ngrx/store-devtools";
import { BrowserModule } from "@angular/platform-browser";
import { MatCardModule} from "@angular/material/card";
import { MatInputModule} from "@angular/material/input";
import { MatIconModule} from "@angular/material/icon";
import { MatButtonModule} from "@angular/material/button";
import { MatFormFieldModule} from "@angular/material/form-field";
import { MatPaginatorModule} from "@angular/material/paginator";
import { MatCheckboxModule} from "@angular/material/checkbox";
import { MatTableModule} from "@angular/material/table";
import { MatSortModule} from "@angular/material/sort";
import { MatSelectModule} from "@angular/material/select";
import { CommonModule, NgFor } from "@angular/common";
import { NgrxFormsModule } from "ngrx-forms";
import { MaterialModule } from "../shared/material.module";
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatToolbar } from '@angular/material/toolbar';
import { MatDialog } from '@angular/material/dialog';

@NgModule({
    declarations: [
        AppComponent,
        AuthComponent,
        PanelComponent,
        // tu dodajemy componenty
    ],
    imports: [
        AppRoutingModule,
        HttpClientModule,
        BrowserModule,
        MatCardModule,
        BrowserAnimationsModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatCheckboxModule,
        MatTableModule,
        MatToolbar,
        MatSortModule,
        MatSelectModule,
        NgFor,
        FormsModule,
        NgrxFormsModule,
        CommonModule,
        MaterialModule,
        StoreModule.forRoot(appReducer, {
            runtimeChecks: {
                strictStateImmutability: false,
                strictActionImmutability: false
            }
        }),
        EffectsModule.forRoot(rootEffect),
        StoreDevtoolsModule.instrument({ maxAge: 10}),
        
        // tu dodajemy importy np angular materials :)
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: UniversalAppInterceptor,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})

export class AppModule{
    constructor(private store: Store<IMainState>){
        this.store.dispatch(setEnviroment());
        this.store.complete();
    }
}