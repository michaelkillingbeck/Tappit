import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'concatsports'
})

export class ConcatSports implements PipeTransform {
    transform(value: string[], character: string): string {
        if(value.length) {
            return value.join(character);
        } else {
            return 'N/A';
        }
    }
}