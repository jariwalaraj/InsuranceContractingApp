import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as CarriersStore from '../store/Carriers';

type CarriersProps =
    CarriersStore.CarriersState 
    & typeof CarriersStore.actionCreators 
    & RouteComponentProps<{ startDateIndex: string }>; 

class CarriersData extends React.PureComponent<CarriersProps> {
  public componentDidMount() {
    this.ensureDataFetched();
  }

  public componentDidUpdate() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Carriers</h1>
        {this.renderCarriersTable()}
        {this.renderPagination()}
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
      this.props.requestCarriers(startDateIndex);
  }

  private renderCarriersTable() {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Business Name</th>
            <th>Business Address</th>
            <th>Phone Number</th>
          </tr>
        </thead>
            <tbody>
                {this.props.Carriers.map((Carrier: CarriersStore.Carrier) =>
                    <tr key={Carrier.carrierId}>
                        <td>{Carrier.businessName}</td>
                        <td>{Carrier.businessAddress}</td>
                        <td>{Carrier.phoneNumber}</td>
                    </tr>
          )}
        </tbody>
      </table>
    );
  }

  private renderPagination() {
    const prevStartDateIndex = (this.props.startDateIndex || 0) - 5;
    const nextStartDateIndex = (this.props.startDateIndex || 0) + 5;

    return (
      <div className="d-flex justify-content-between">
            <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-carriers/${prevStartDateIndex}`}>Previous</Link>
        {this.props.isLoading && <span>Loading...</span>}
            <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-carriers/${nextStartDateIndex}`}>Next</Link>
      </div>
    );
  }
}

export default connect(
    (state: ApplicationState) => state.carriers, 
    CarriersStore.actionCreators 
)(CarriersData as any);
