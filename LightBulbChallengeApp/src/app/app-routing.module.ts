import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LightBulbCalculatorComponent } from './light-bulb-calculator/light-bulb-calculator.component';


const routes: Routes = [
  { path: '', component: LightBulbCalculatorComponent, pathMatch: 'full' },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
