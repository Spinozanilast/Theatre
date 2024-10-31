import { Component } from '@angular/core';
import { HeaderComponent } from '@commom/header/header.component';

@Component({
    selector: 'app-about-page',
    standalone: true,
    imports: [HeaderComponent],
    templateUrl: './about-page.component.html',
    styleUrl: './about-page.component.less',
})
export class AboutPageComponent {}
