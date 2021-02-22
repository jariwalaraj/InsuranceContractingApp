import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
    <h1>Life Insurance Contracting Platform!</h1>
        <p>Built with .net Core, React and Redux. Used out of the box template available from VS 2019.</p>
  </div>
);

export default connect()(Home);
