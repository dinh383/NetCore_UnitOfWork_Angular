import { Routes } from "@angular/router";
import { ResoureManagementComponent } from "@app/main/modules/resoure-management/resoure-management.component";
import { VideoComponent } from "@app/main/modules/resoure-management/video/video.component";

export const resoureRoutes: Routes = [
    {
      path: '',
      component: VideoComponent,
      children: [
        {
          path: 'video-list',
          component: VideoComponent
        }
      ]
    },
  ];