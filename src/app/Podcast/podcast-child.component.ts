import { PodcastDto } from './podcast.model';
import { Component, EventEmitter, Output } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";
import { ICellRendererParams } from "ag-grid-community";

import Swal from "sweetalert2";

@Component({
  selector : "podcast_child",
  templateUrl: "./podcast-child.component.html",
  styles: [
    `
      .btn {
        line-height: 1.5;
        padding-left: 2px;
        padding-right: 2px;
      }
    `,
  ]
})
export class PodcastChild implements ICellRendererAngularComp{
  public params: ICellRendererParams | any;

  public mapKeys: any;
  constructor(){}
  podcast: any;
  ngOnInit(){}
  agInit(params: ICellRendererParams): void {
    this.params=params;
  }
  refresh(): boolean{
    return false;
  }
  showAddEdit() {
    this.params.context.componentParent.ShowAddEditModal(this.params.data);
  }

  showDelete() {
    this.params.context.componentParent.showDelete(this.params.data);
  }
}
