import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'arrayValuesSeparator',
    standalone: true,
})
export class ArrayValuesSeparatorPipe implements PipeTransform {
    transform(value: any[], separator: string = ', '): string | null {
        return value.join(separator);
    }
}
