import * as React from "react";
import { render } from "react-dom";
import { App } from "./App";
import { AppModel } from "./AppModel";

const model = new AppModel();
render(<App model={model}/>, document.getElementById("app"));
