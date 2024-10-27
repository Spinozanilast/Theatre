import { Routes } from '@angular/router';
import { LayoutComponent } from './common/layout/layout.component';
import { MainPageComponent } from '@pages/main-page/main-page.component';

export const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', component: MainPageComponent },
            // { path: 'events', component: EventsPageComponent },
            // { path: 'halls', component: HallsPageComponent },
        ],
    },
];
