import { MatCardModule} from "@angular/material/card";
import { MatInputModule} from "@angular/material/input";
import { MatIconModule} from "@angular/material/icon";
import { MatButtonModule} from "@angular/material/button";
import { MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule} from "@angular/material/form-field";
import { MatPaginatorModule} from "@angular/material/paginator";
import { MatCheckboxModule} from "@angular/material/checkbox";
import { MatTableModule} from "@angular/material/table";
import { MatSortModule} from "@angular/material/sort";
import { MatSelectModule} from "@angular/material/select";

import { NgrxMatSelectViewAdapter } from "./mat-select-view-adapter";
import { NgModule } from "@angular/core";

@NgModule({
    imports:[
        MatCardModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatCheckboxModule,
        MatTableModule,
        MatSortModule,
        MatSelectModule,
    ],
    declarations: [
        NgrxMatSelectViewAdapter
    ],
    exports: [
        MatCardModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatCheckboxModule,
        MatTableModule,
        MatSortModule,
        MatSelectModule,
        NgrxMatSelectViewAdapter
    ],
    providers: [
        { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { float: 'always' } },
    ]
})
export class MaterialModule { }