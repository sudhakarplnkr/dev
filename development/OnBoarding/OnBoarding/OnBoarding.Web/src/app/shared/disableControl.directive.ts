import { NgControl } from '@angular/forms';
import { Directive, Input } from '@angular/core';

@Directive({

    selector: '[disableControl]'
})

export class DisableControlDirective {

    @Input() set disableControl(isDisable: boolean) {

        const action = isDisable ? 'disable' : 'enable';
        this.ngControl.control[action]();
    }

    constructor(private ngControl: NgControl) {
    }
}