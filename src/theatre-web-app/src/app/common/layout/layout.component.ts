import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from '@commom/footer/footer.component';
import { NavBarComponent } from '@commom/nav-bar/nav-bar.component';

@Component({
    selector: 'app-layout',
    standalone: true,
    imports: [RouterOutlet, FooterComponent, NavBarComponent],
    templateUrl: './layout.component.html',
    styleUrl: './layout.component.less',
})
export class LayoutComponent {}
