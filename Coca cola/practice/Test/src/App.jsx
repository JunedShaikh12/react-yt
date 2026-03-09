import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  const accountId = 12345;
  let accountEmail = "Juned.google.com";
  let accountPassword;
  // accountCity = "jaipur";

  // accountId = 8878787;
  console.log(accountId);
  console.table([accountId,accountEmail,accountPassword]);
  return (
    <>
      <h3>HI Juned</h3>
    </>
  )
}

export default App
