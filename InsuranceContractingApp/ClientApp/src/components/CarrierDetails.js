"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var CarriersStore = require("../store/Carriers");
var react_redux_1 = require("react-redux");
var CarrierDetails = /** @class */ (function (_super) {
    __extends(CarrierDetails, _super);
    function CarrierDetails() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    CarrierDetails.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h1", { id: "itemLabel" }, "Carrier"),
            this.loadCarrier()));
    };
    CarrierDetails.prototype.loadCarrier = function () {
        console.log('hey' + this.props.match.params.id);
        return (React.createElement("table", { className: 'table table-striped' },
            React.createElement("thead", null,
                React.createElement("tr", null,
                    React.createElement("th", null, "Property Name"),
                    React.createElement("th", null, "Field"))),
            React.createElement("tbody", null)));
    };
    return CarrierDetails;
}(React.PureComponent));
exports.default = react_redux_1.connect(function (state) { return state.carriers; }, CarriersStore.actionCreators)(CarrierDetails);
//# sourceMappingURL=CarrierDetails.js.map