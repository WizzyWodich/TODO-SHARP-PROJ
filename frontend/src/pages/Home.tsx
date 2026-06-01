import PageTransition from "../components/PageTransition";
import SideBar from "../components/SideBar";
import Statistic from "../components/Statistic";
import Header from "../components/HeaderProps";
import useAuth from "../hooks/useAuth";


export function HomePage() {
    const { user } = useAuth();

    return (
        <PageTransition>
            <div className="min-h-screen bg-[#20211f] text-white flex p-2 gap-2">
                <SideBar />
                <main className="flex-1 bg-[#171717] border border-zinc-800 rounded-3xl p-5">
                    <Header username={user?.username} />
                    <div className="grid grid-cols-2 gap-3 mb-6">
                        <Statistic />
                    </div>
                </main>
            </div>
        </PageTransition>
    );
}