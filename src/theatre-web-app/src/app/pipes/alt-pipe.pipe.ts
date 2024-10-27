import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'altPipe',
    standalone: true,
})
export class ImageAltPipe implements PipeTransform {
    transform(value: string, text: string = 'image'): string | null {
        return value + ' ' + text;
    }
}
