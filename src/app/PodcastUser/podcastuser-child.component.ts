import { Component, Input } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";
import { ICellRendererParams } from "ag-grid-community";


@Component({
  selector : "podcastuser_child",
  templateUrl: "./podcastuser-child.component.html",
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
export class PodcastUserChild{
  params: ICellRendererParams = {} as ICellRendererParams;

  agInit(params: ICellRendererParams): void {
    this.params = params;
  }
}
