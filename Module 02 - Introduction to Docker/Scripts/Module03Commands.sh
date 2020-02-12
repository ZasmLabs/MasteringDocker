ls
pwd
cd
mkdir
rmdir
rm
touch
cat
vi
man <command_name> (ESC:q to exit)
man ls
man cp
man cgroup
apt-get
wget
curl
wget -q https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1
dotnet --version
echo $PATH
which dotnet
ls -l /usr/bin/dotnet
ls -l /usr/share/dotnet/dotnet
cd /usr/bin
ln -s ../sharare/dotnet/dotnet my-dotnet
sudo ln -s ../share/dotnet/dotnet my-dotnet
ls -l *dotnet
my-dotnet --version
pidof firefox
systemctl status 6217 | group CGroup
mkdir /sys/fs/cgroup/cpu/cg1
echo $$ > /sys/fs/cgroup/cpu/cg1/cgroup.procs
lsns
sudo apt-get remove docker docker-engine docker.io containerd runc
sudo apt-get install docker
sudo apt-get install docker-io
sudo apt-get install containerd
sudo apt-get install runc
sudo docker run hello-world
docker run --help | grep interactive
docker run --help | grep tty
docker run --interactive --tty hello-world bash
docker run --interactive --tty hello-world sh
docker run --interactive --tty busybox bash
docker run --interactive --tty busybox sh
docker run -it busybox bash
