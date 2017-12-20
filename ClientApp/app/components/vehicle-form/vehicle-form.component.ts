import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../Services/vehicle.service';


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

  constructor(private vehicleService: VehicleService,) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes => 
      this.makes = makes);

    this.vehicleService.getFetures().subscribe(features =>
    this.features = features);
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.k);
    this.models = selectedMake ? selectedMake.models : [];
  }
}