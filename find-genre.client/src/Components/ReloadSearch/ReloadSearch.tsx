import { ReloadIcon } from "@radix-ui/react-icons";
import styles from './ReloadSearch.module.css'

type Props = {
  handleReload: () => void;
};

const ReloadSearch = (props: Props) => {
  return (
    <>
      <ReloadIcon onClick={() => props.handleReload()} className={styles.icon} />
    </>
  );
};

export default ReloadSearch;
