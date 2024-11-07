import { Routes } from '@angular/router';
import { LayoutComponent } from './common/layout/layout.component';
import { MainPageComponent } from '@pages/main-page/main-page.component';
import { AboutPageComponent } from '@pages/about-page/about-page.component';
import { ErrorPageComponent } from '@pages/error-page/error-page.component';

export const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', component: MainPageComponent },
            { path: 'about', component: AboutPageComponent },
        ],
    },
    {
        path: 'error',
        component: ErrorPageComponent,
    },
];
