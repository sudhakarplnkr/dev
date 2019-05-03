//import { Component } from '@angular/core';
//import { DataTableResource } from 'angular-2-data-table';
//import persons from './data-table-data';


//@Component({
//    selector: 'data-table-demo-1',
//    providers: [],
//    templateUrl: 'app/Data/data-table.html',
//    styleUrls: ['app/Data/data-table.css'],
//    styles: [`
//    .even { color: red; }
//    .odd { color: green; }
//    `],
//})
//export class DataTable {

//    itemResource = new DataTableResource(persons);
//    items = [];
//    itemCount = 0;

//    constructor() {
//        this.itemResource.count().then(count => this.itemCount = count);
//    }

//    reloadItems(params) {
//        this.itemResource.query(params).then(items => this.items = items);
//    }

//    // special properties:

//    rowClick(rowEvent) {
//        console.log('Clicked: ' + rowEvent.row.item.name);
//    }

//    rowDoubleClick(rowEvent) {
//        alert('Double clicked: ' + rowEvent.row.item.name);
//    }
    

//    rowTooltip(item) { return item.jobTitle; }
//}
