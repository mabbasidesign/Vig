import { Component, OnInit } from '@angular/core';
import { MakeService } from '../../Services/make.service';
import { FeatureService } from '../../Services/feature.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})

export class VehicleFormComponent implements OnInit {
  makes: any[]; 
  models: any[];
  vehicle: any = {};
  features: any[];

  constructor(
    private makeService: MakeService,
    private featureService: FeatureService  ) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes => 
      this.makes = makes);

    this.featureService.getFetures().subscribe(features =>
    this.features = features);
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.k);
    this.models = selectedMake ? selectedMake.models : [];
  }
}