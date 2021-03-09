import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as AdvisorsStore from '../store/Advisors';

type AdvisorsProps =
    AdvisorsStore.AdvisorsState
    & typeof AdvisorsStore.actionCreators 
    & RouteComponentProps<{ startDateIndex: string }>;

class AdvisorsData extends React.PureComponent<AdvisorsProps> {
  public componentDidMount() {
    this.ensureDataFetched();
  }

  public componentDidUpdate() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <h1 id="tabelLabel">Advisors</h1>
        {this.renderAdvisorsTable()}
        {this.renderPagination()}
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
      const params = new URLSearchParams(this.props.location.search);
      const startDateIndex = parseInt(params.get('startDateIndex') || '1', 10);
      this.props.requestAdvisors(startDateIndex);
  }

    private renderAdvisorsTable() {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Address</th>
            <th>Phone Number</th>
            <th>Health Status</th>
          </tr>
        </thead>
            <tbody>
                {this.props.Advisors.map((Advisor: AdvisorsStore.Advisor) =>
                    <tr key={Advisor.advisorsId}>
                        <td>{Advisor.firstName}</td>
                        <td>{Advisor.lastName}</td>
                        <td>{Advisor.address}</td>
                        <td>{Advisor.phoneNumber}</td>
                        <td>{Advisor.healthStatus}</td>
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
            <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-advisors/${prevStartDateIndex}`}>Previous</Link>
        {this.props.isLoading && <span>Loading...</span>}
            <Link className='btn btn-outline-secondary btn-sm' to={`/fetch-advisors/${nextStartDateIndex}`}>Next</Link>
      </div>
    );
  }
}

export default connect(
    (state: ApplicationState) => state.advisors,
    AdvisorsStore.actionCreators
)(AdvisorsData as any);
