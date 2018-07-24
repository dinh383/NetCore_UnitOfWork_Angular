import { Routes } from '@angular/router';
import { MainComponent } from '@app/main/main.component';

export const mainRoutes: Routes = [
    {
        path: 'main', component: MainComponent, children: [
            { path: '', redirectTo: 'resoure-management/video-list', pathMatch: 'full' },
            { path: 'resoure-management', loadChildren: './modules/resoure-management/resoure-management.module#ResoureManagementModule' },
            { path: 'home-study', loadChildren: './modules/home-study/home-study.module#HomeStudyModule' }
        ]
    }
]

