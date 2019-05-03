import { Component, OnInit, ChangeDetectorRef  } from '@angular/core';
import { PreLoaderService } from '../shared/preLoader.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'loader',
    templateUrl: '../shared/preLoader.component.html',
    styleUrls: ['../shared/preLoader.component.css']    
})

export class PreLoaderComponent {
    viewLoader: boolean;

    constructor(private preLoaderService: PreLoaderService, private cdr: ChangeDetectorRef) {        
         Observable.interval(100).takeWhile(() => true).subscribe(() => this.getPreloaderCount());;
    }    

    getPreloaderCount() {
        this.viewLoader = this.preLoaderService.getPreloaderCount() > 0;
    }   
}