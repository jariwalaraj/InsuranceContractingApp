import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as MGAsStore from '../store/MGAs';

// At runtime, Redux will merge together...
type MGAProps =
    MGAsStore.MGAsState // ... state we've requested from the Redux store
    & typeof MGAsStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ }>; // ... plus incoming routing parameters

class MGAsData extends React.PureComponent<MGAProps> {
  // This method is called when the component is first added to the document
  public componentDidMount() {
    this.ensureDataFetched();
  }

  // This method is called when the route parameters change
  public componentDidUpdate() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Weather forecast</h1>
        <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
        {this.renderForecastsTable()}
        {this.renderPagination()}
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
      const params = new URLSearchParams(this.props.location.search);
      const startDateIndex = parseInt(params.get('startDateIndex') || '1', 10);
      this.props.requestMGAs(startDateIndex);
  }

  private renderForecastsTable() {
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
                {this.props.MGAs.map((MGA: MGAsStore.MGA) =>
                    <tr key={MGA.mgaId}>
                        <td>{MGA.businessName}</td>
                        <td>{MGA.businessAddress}</td>
                        <td>{MGA.phoneNumber}</td>
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
            <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-mgas/${prevStartDateIndex}`}>Previous</Link>
        {this.props.isLoading && <span>Loading...</span>}
            <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-mgas/${nextStartDateIndex}`}>Next</Link>
      </div>
    );
  }
}

export default connect(
    (state: ApplicationState) => state.MGAs, // Selects which state properties are merged into the component's props
    MGAsStore.actionCreators // Selects which action creators are merged into the component's props
)(MGAsData as any);
