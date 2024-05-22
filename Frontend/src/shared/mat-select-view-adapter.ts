import { AfterViewInit, Directive, OnDestroy, forwardRef } from "@angular/core";
import { MatSelect } from "@angular/material/select";
import { FormViewAdapter, NGRX_FORM_VIEW_ADAPTER } from "ngrx-forms";
import { Subscription } from "rxjs";

@Directive({
    selector: 'mat-select[ngrxFromControlState]',
    providers: [{
        provide: NGRX_FORM_VIEW_ADAPTER,
        useExisting: forwardRef(() => NgrxMatSelectViewAdapter),
        multi: true
    }]
})

export class NgrxMatSelectViewAdapter implements FormViewAdapter, AfterViewInit, OnDestroy {
    private value: any;
    private subscription: Subscription[] = [];

    constructor(private matSelect: MatSelect) {}

    ngAfterViewInit(){
        this.subscription.push(
            this.matSelect.options.changes.subscribe(() => {
                Promise.resolve().then(() => this.matSelect.writeValue(this.value));
            })
        );
    }

    ngOnDestroy(): void {
        this.subscription.forEach(s => s.unsubscribe());
    }

    setViewValue(value: any) {
        this.value = value;

        const selectedOption = this.matSelect.selected;

        if(selectedOption) {
            if(Array.isArray(selectedOption) && Array.isArray(value)) {
                if(value.length === selectedOption.length && value.every((v,i) => v === selectedOption[i])){
                    return;
                }
            } else if(!Array.isArray(selectedOption)){
                if(value === selectedOption.value){
                    return;
                }
            }
        }

        Promise.resolve().then(() => this.matSelect.writeValue(value));
    }

    setOnChangeCallback(fn: any) {
        this.matSelect.registerOnChange(value => {
            this.value = value;
            fn(value);
        });
    }

    setOnTouchedCallback(fn: any){
        this.matSelect.registerOnTouched(fn);
    }

    setIsDisabled(isDisabled: boolean) {
        this.matSelect.setDisabledState(isDisabled);
    }
}