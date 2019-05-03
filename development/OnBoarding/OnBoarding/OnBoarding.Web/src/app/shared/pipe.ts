import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'groupBy' })
export class GroupByPipe implements PipeTransform {
    transform(value: Array<any>, field: string): Array<any> {
        if (value) {
            const groupedObj = value.reduce((prev, cur) => {
                if (!prev[cur[field]]) {
                    prev[cur[field]] = [cur];
                } else {
                    prev[cur[field]].push(cur);
                }
                return prev;
            }, {});
            return Object.keys(groupedObj).map(key => ({ key, value: groupedObj[key] }));
        }
    }
}

//@Pipe({
//    name: 'filter'
//})
//export class FilterPipe implements PipeTransform {
//    transform(values: any[], args: any[]): any {
//        if (!values) return values;
//        if (!args || args.length<0) return values;
//        return values.filter((value) => {
//            for (let i = 0; i < args.length; i++) {
//                let val = value[args[i][0]];
//                let text = args[i][1];
//                if (!val || !text) return true;
//                if (val.toLowerCase().indexOf(text.toLowerCase()) > -1) {
//                    return true;
//                }
//            }
//            return false;
//        });
//    }
//}

@Pipe({
    name: 'filter'
})
export class FilterPipe implements PipeTransform {
    transform(items: any[], fields: string[], values: string[]): any[] {
        if (!items) return [];
        if (!values || values.filter(l => l).length < 1) return items;
        return items.filter(it =>
        {
            for (let i = 0; i < fields.length; i++) {
                if (it[fields[i]].toLowerCase().indexOf(values[i].toLowerCase()) > -1)
                {
                    return true;
                }
            }
            return false;
        }
        );
    }
}

//@Pipe({
//    name: 'filter'
//})
//export class FilterPipe implements PipeTransform {
//    transform(items: any[], field: string, value: string): any[] {
//        if (!items) return [];
//        if (!value) return items;
//        return items.filter(it => it[field].indexOf(value) > -1);
//    }
//}

//export class GroupByPipe implements PipeTransform {
//    transform(value: Array<any>, field: string): Array<any> {
//        const groupedObj = value.reduce((prev, cur) => {
//            if (!prev[cur[field]]) {
//                prev[cur[field]] = [cur];
//            } else {
//                prev[cur[field]].push(cur);
//            }
//            return prev;
//        }, {});
//        return Object.keys(groupedObj).map(key => return { key, value: groupedObj[key] });
//    }
//}

//export class GroupByPipe implements PipeTransform {

//    transform(items: Array<any>, conditions: { [field: string]: any }): Array<any> {
//        if (items !== undefined) {
//            return items.filter(item => {
//                for (let field in conditions) {
//                    if (item[field] !== conditions[field]) {
//                        return false;
//                    }
//                }
//                return true;
//            });
//        }
//    }
//}

//@Pipe({
//    name: 'filter',
//    pure: false
//})
//export class FilterPipe implements PipeTransform {
//    transform(items: any[], term): any {
//        console.log('term', term);

//        return term
//            ? items.filter(item => item.title.indexOf(term) !== -1)
//            : items;
//    }
//}

//@Pipe({
//    name: 'sortBy'
//})
//export class SortByPipe implements PipeTransform {
//    transform(items: any[], sortedBy: string): any {
//        console.log('sortedBy', sortedBy);

//        return items.sort((a, b) => { return b[sortedBy] - a[sortedBy] });
//    }
//}