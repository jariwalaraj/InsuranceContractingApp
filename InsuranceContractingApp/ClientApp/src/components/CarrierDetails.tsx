import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import * as CarriersStore from '../store/Carriers';
import { ApplicationState } from '../store';
import { connect } from 'react-redux';

//type CarrierDetailsProps = {
//    carrierId: number,
//    businessName: string,
//    businessAddress: string,
//    phoneNumber: string

//}

type CarrierDetailsProps =
    CarriersStore.CarriersState
    & typeof CarriersStore.actionCreators
    & RouteComponentProps<{ id? : string }>;

class CarrierDetails extends React.PureComponent<CarrierDetailsProps>
{
    public render() {
        return (
            <React.Fragment>
                <h1 id="itemLabel">Carrier</h1>
                    {this.loadCarrier()}
            </React.Fragment>
            );
    }

    componentDidMount() {

    }
    private loadCarrier() {
        console.log('hey' + this.props.match.params.id);
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Property Name</th>
                        <th>Field</th>
                    </tr>
                </thead>
                <tbody>
                    
                </tbody>
            </table>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.carriers,
    CarriersStore.actionCreators
)(CarrierDetails as any);
